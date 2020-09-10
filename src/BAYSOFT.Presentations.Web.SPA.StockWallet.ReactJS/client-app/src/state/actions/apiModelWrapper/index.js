// - Import Types
import {
    CREATE_API_SERVICE, CREATE_API_FILTER,
    REQUEST_DATA, RECEIVE_DATA,
    REQUEST_DELETE_DATA, RECEIVE_DELETE_DATA,
    REQUEST_PATCH_DATA, RECEIVE_PATCH_DATA,
    REQUEST_PUT_DATA, RECEIVE_PUT_DATA,
    REQUEST_POST_DATA, RECEIVE_POST_DATA
} from './types';

// - Import Actions
import {
    CreateApiService,
    CreateApiFilter,
} from './actions';

const types = {
    CREATE_API_SERVICE, CREATE_API_FILTER,
    REQUEST_DATA, RECEIVE_DATA,
    REQUEST_DELETE_DATA, RECEIVE_DELETE_DATA,
    REQUEST_PATCH_DATA, RECEIVE_PATCH_DATA,
    REQUEST_PUT_DATA, RECEIVE_PUT_DATA,
    REQUEST_POST_DATA, RECEIVE_POST_DATA
};

const actions = {
    CreateApiService,
    CreateApiFilter,
};

export {
    types, actions
};