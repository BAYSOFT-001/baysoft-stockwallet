﻿import { ApiModelWrapperActionType } from '../../actions';

const INITIAL_STATE = {
    apiFilters: [],
    apiServices: [],
    queries: {
        collections: {},
        entities: {}
    },
    commands: {
        deletes: {},
        patchs: {},
        posts: {},
        puts: {}
    }
};
const setQueryCollection = (state, payload) => {
    state.queries.collections[payload.endPoint] = payload;
    return {
        ...state,
        queries: {
            ...state.queries,
            collections: {
                ...state.queries.collections
            }
        }
    };
};
const setQueryEntity = (state, payload) => {
    state.queries.entities[payload.endPoint] = payload;
    return {
        ...state,
        queries: {
            ...state.queries,
            entities: {
                ...state.queries.entities
            }
        }
    };
};
const setCommandDelete = (state, payload) => {
    state.commands.deletes[payload.endPoint] = payload;
    return {
        ...state,
        commands: {
            ...state.commands,
            deletes: {
                ...state.commands.deletes
            }
        }
    };
};
const setCommandPatch = (state, payload) => {
    state.commands.patchs[payload.endPoint] = payload;
    return {
        ...state,
        commands: {
            ...state.commands,
            patchs: {
                ...state.commands.patchs
            }
        }
    };
};
const setCommandPost = (state, payload) => {
    state.commands.posts[payload.endPoint] = payload;
    return {
        ...state,
        commands: {
            ...state.commands,
            posts: {
                ...state.commands.posts
            }
        }
    };
};
const setCommandPut = (state, payload) => {
    state.commands.puts[payload.endPoint] = payload;
    return {
        ...state,
        commands: {
            ...state.commands,
            puts: {
                ...state.commands.puts
            }
        }
    };
};
export const ApiModelWrapperReducer = (state = INITIAL_STATE, action) => {
    //console.log(action.type);
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
        case ApiModelWrapperActionType.types.REQUEST_GETBYFILTER: return setQueryCollection(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_GETBYFILTER: return setQueryCollection(state, action.payload);
        case ApiModelWrapperActionType.types.REQUEST_GETBYID: return setQueryEntity(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_GETBYID: return setQueryEntity(state, action.payload);
        case ApiModelWrapperActionType.types.REQUEST_DELETE: return setCommandDelete(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_DELETE: return setCommandDelete(state, action.payload);
        case ApiModelWrapperActionType.types.REQUEST_PATCH: return setCommandPatch(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_PATCH: return setCommandPatch(state, action.payload);
        case ApiModelWrapperActionType.types.REQUEST_POST: return setCommandPost(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_POST: return setCommandPost(state, action.payload);
        case ApiModelWrapperActionType.types.REQUEST_PUT: return setCommandPut(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_PUT: return setCommandPut(state, action.payload);
        default: return state;
    }
}