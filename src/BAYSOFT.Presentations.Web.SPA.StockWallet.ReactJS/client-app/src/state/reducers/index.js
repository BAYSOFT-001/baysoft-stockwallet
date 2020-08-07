import { combineReducers } from 'redux';

import { ApplicationReducer } from './application';

export const Reducers = combineReducers({
    applicationState: ApplicationReducer
});