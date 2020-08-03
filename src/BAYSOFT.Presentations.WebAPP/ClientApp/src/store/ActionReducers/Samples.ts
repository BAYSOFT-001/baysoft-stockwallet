import { Action, Reducer } from 'redux';
import { AppThunkAction } from '../';

//import { GetSamplesByFilterQuery } from '../../services/samples/queries/GetSamplesByFilterQuery';

// --------------------
// STATE
export interface GetSamplesByFilterState {
    isLoading: boolean;
    pageNumber?: number;
    pageSize?: number;
    query?: string;
    samples: Sample[];
}

export interface WrapResponse<TEntity> {
    data: TEntity[];
}

export interface Sample {
    sampleID: number;
    description: string;
}

// --------------------
// ACTIONS
interface RequestGetSamplesByFilterAction {
    type: 'REQUEST_GETSAMPLESBYFILTER_ACTION';
    pageNumber: number;
    pageSize: number;
    query: string;
}
interface ReceiveGetSamplesByFilterAction {
    type: 'RECEIVE_GETSAMPLESBYFILTER_ACTION';
    pageNumber: number;
    pageSize: number;
    query: string;
    samples: Sample[];
}

type KnownAction = RequestGetSamplesByFilterAction | ReceiveGetSamplesByFilterAction;

// --------------------
// ACTION CREATORS
export const actionCreators = {
    requestGetSamplesByFilter: (pageNumber: number, pageSize: number, query: string): AppThunkAction<KnownAction> => (dispatch, getState) => {
        const appState = getState();
        console.log(appState && appState.getSamplesByFilter && (pageNumber !== appState.getSamplesByFilter.pageNumber || pageSize !== appState.getSamplesByFilter.pageSize || query !== appState.getSamplesByFilter.query));
        if (appState && appState.getSamplesByFilter && (pageNumber !== appState.getSamplesByFilter.pageNumber || pageSize !== appState.getSamplesByFilter.pageSize || query !== appState.getSamplesByFilter.query)) {
            console.log('GetSamplesByFilter');
            let _query = query ? query : '';
            let _pageNumber = pageNumber ? pageNumber : 1;
            let _pageSize = pageSize ? pageSize : 10;

            fetch('https://localhost:4101/api/samples' + `?query=${_query}&pageNumber=${_pageNumber}&pageSize=${_pageSize}&querystrict=true`)
                .then(response => response.json() as Promise<WrapResponse<Sample>>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_GETSAMPLESBYFILTER_ACTION', pageNumber: pageNumber, pageSize: pageSize, query: query, samples: data.data });
                });

            dispatch({ type: 'REQUEST_GETSAMPLESBYFILTER_ACTION', pageNumber: pageNumber, pageSize: pageSize, query: query });
        }
    }
};

// --------------------
// REDUCER
const unloadedState: GetSamplesByFilterState = { samples: [], isLoading: false };

export const reducer: Reducer<GetSamplesByFilterState> = (state: GetSamplesByFilterState | undefined, incomingAction: Action): GetSamplesByFilterState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_GETSAMPLESBYFILTER_ACTION':
            return {
                pageNumber: action.pageNumber,
                pageSize: action.pageSize,
                query: action.query,
                samples: state.samples,
                isLoading: true
            };
        case 'RECEIVE_GETSAMPLESBYFILTER_ACTION':
            if (action.pageNumber === state.pageNumber && action.pageSize === state.pageSize && action.query === state.query) {
                return {
                    pageNumber: action.pageNumber,
                    pageSize: action.pageSize,
                    query: action.query,
                    samples: action.samples,
                    isLoading: false
                };
            }
            break;
    }

    return state;
};