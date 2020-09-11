import { ApiModelWrapperActionType } from '../../actions';

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

export const ApiModelWrapperReducer = (state = INITIAL_STATE, action) => {
    console.log(action.type);
    console.log(action.payload);
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
        case ApiModelWrapperActionType.types.REQUEST_GETBYFILTER: {
            state.queries.collections[action.payload.endPoint] = action.payload;
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
        case ApiModelWrapperActionType.types.RECEIVE_GETBYFILTER: {
            state.queries.collections[action.payload.endPoint] = action.payload;
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
        case ApiModelWrapperActionType.types.REQUEST_GETBYID: {
            state.queries.entities[action.payload.endPoint] = action.payload;
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
        case ApiModelWrapperActionType.types.RECEIVE_GETBYID: {
            state.queries.entities[action.payload.endPoint] = action.payload;
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
        case ApiModelWrapperActionType.types.REQUEST_DELETE: {
            state.commands.deletes[action.payload.endPoint] = action.payload;
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
        case ApiModelWrapperActionType.types.RECEIVE_DELETE: {
            state.commands.deletes[action.payload.endPoint] = action.payload;
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
        case ApiModelWrapperActionType.types.REQUEST_PATCH: {
            state.commands.patchs[action.payload.endPoint] = action.payload;
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
        case ApiModelWrapperActionType.types.RECEIVE_PATCH: {
            state.commands.patchs[action.payload.endPoint] = action.payload;
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
        case ApiModelWrapperActionType.types.REQUEST_POST: {
            state.commands.posts[action.payload.endPoint] = action.payload;
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
        case ApiModelWrapperActionType.types.RECEIVE_POST: {
            state.commands.posts[action.payload.endPoint] = action.payload;
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
        case ApiModelWrapperActionType.types.REQUEST_PUT: {
            state.commands.puts[action.payload.endPoint] = action.payload;
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
        case ApiModelWrapperActionType.types.RECEIVE_PUT: {
            state.commands.puts[action.payload.endPoint] = action.payload;
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
        default: return state;
    }
}