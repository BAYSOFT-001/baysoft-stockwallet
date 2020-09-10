import { ApiModelWrapperActionType } from '../../actions';

const INITIAL_STATE = {
    apiFilters: [],
    apiServices: [],
    requests: {},
    testes: {}
};

export const ApiModelWrapperReducer = (state = INITIAL_STATE, action) => {
    console.log(action.type);
    //console.log(action.payload);
    switch (action.type) {
        case ApiModelWrapperActionType.types.CREATE_API_SERVICE: return {
            ...state,
            apiServices: [
                ...state.apiServices.filter(apiService => apiService.id !== action.payload.id),
                action.payload
            ]
        };
        case ApiModelWrapperActionType.types.CREATE_API_FILTER: return {
            ...state,
            apiFilters: [
                ...state.apiFilters.filter(apiFilter => apiFilter.id !== action.payload.id),
                action.payload
            ]
        };
        case ApiModelWrapperActionType.types.REQUEST_DATA: {
            state.requests[action.payload.endPoint] = action.payload;
            return {
                ...state,
                requests: { ...state.requests }
            };
        };
        case ApiModelWrapperActionType.types.RECEIVE_DATA: {
            state.requests[action.payload.endPoint] = action.payload;
            return {
                ...state,
                requests: { ...state.requests }
            };
        };
        default: return state;
    }
}