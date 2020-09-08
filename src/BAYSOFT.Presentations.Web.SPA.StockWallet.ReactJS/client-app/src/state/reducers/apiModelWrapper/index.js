import { ApiModelWrapperActionType } from '../../actions';

const INITIAL_STATE = {
    apiFilters: [],
    apiServices: [],
    requests: [],
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
        }; break;
        case ApiModelWrapperActionType.types.CREATE_API_FILTER: return {
            ...state,
            apiFilters: [
                ...state.apiFilters.filter(apiFilter => apiFilter.id !== action.payload.id),
                action.payload
            ]
        }; break;
        case ApiModelWrapperActionType.types.REQUEST_DATA: {
            let requests = state.requests.filter(request => request.endPoint === action.payload.endPoint);
            return {
                ...state,
                requests: [
                    ...state.requests.filter(request => request.endPoint !== action.payload.endPoint),
                    {
                        endPoint: action.payload.endPoint,
                        timeStamp: action.payload.timeStamp,
                        response: requests && requests.length > 0 ? requests[0].response : null
                    }
                ]
            };
        } break;
        case ApiModelWrapperActionType.types.RECEIVE_DATA: return {
            ...state,
            requests: [
                ...state.requests.filter(request => request.endPoint !== action.payload.endPoint),
                action.payload
            ]
        }; break;
        default: return state;
    }
}