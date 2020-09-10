import { ApiModelWrapperActionType } from '../../actions';

const INITIAL_STATE = {
    apiFilters: [],
    apiServices: [],
    requests: {},
    deletes: {},
    patchs: {},
    posts: {},
    puts: {},
    testes: [],
};

export const ApiModelWrapperReducer = (state = INITIAL_STATE, action) => {
    console.log(action.type);
    console.log(action.payload);
    console.log(state.requests);
    state.testes.map(teste => console.log(teste.endPoint));
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
            state.testes[action.payload.endPoint] = action.payload.endPoint;
            return {
                ...state,
                requests: { ...state.requests },
                testes: [...state.testes]
            };
        };
        case ApiModelWrapperActionType.types.REQUEST_DELETE_DATA: {
            state.deletes[action.payload.endPoint] = action.payload;
            return {
                ...state,
                deletes: { ...state.deletes }
            };
        };
        case ApiModelWrapperActionType.types.RECEIVE_DELETE_DATA: {
            state.deletes[action.payload.endPoint] = null;
            return {
                ...state,
                deletes: { ...state.deletes }
            };
        };
        case ApiModelWrapperActionType.types.REQUEST_PATCH_DATA: {
            state.patchs[action.payload.endPoint] = action.payload;
            return {
                ...state,
                patchs: { ...state.patchs }
            };
        };
        case ApiModelWrapperActionType.types.RECEIVE_PATCH_DATA: {
            state.patchs[action.payload.endPoint] = null;
            return {
                ...state,
                patchs: { ...state.patchs }
            };
        };
        case ApiModelWrapperActionType.types.REQUEST_POST_DATA: {
            state.posts[action.payload.endPoint] = action.payload;
            return {
                ...state,
                posts: { ...state.posts }
            };
        };
        case ApiModelWrapperActionType.types.RECEIVE_POST_DATA: {
            state.posts[action.payload.endPoint] = null;
            return {
                ...state,
                posts: { ...state.posts }
            };
        };
        case ApiModelWrapperActionType.types.REQUEST_PUT_DATA: {
            state.puts[action.payload.endPoint] = action.payload;
            return {
                ...state,
                puts: { ...state.puts }
            };
        };
        case ApiModelWrapperActionType.types.RECEIVE_PUT_DATA: {
            state.puts[action.payload.endPoint] = null;
            return {
                ...state,
                puts: { ...state.puts }
            };
        };
        default: return state;
    }
}