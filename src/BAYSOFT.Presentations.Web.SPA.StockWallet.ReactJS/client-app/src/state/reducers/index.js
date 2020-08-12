﻿import { combineReducers } from 'redux';
import { connectRouter } from 'connected-react-router'

import { ApplicationReducer } from './application';

export const Reducers = (history) => combineReducers({
    router: connectRouter(history),
    applicationState: ApplicationReducer
});