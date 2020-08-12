import { createBrowserHistory } from 'history'
import { applyMiddleware, compose, createStore } from 'redux'
import { routerMiddleware } from 'connected-react-router'

import { Reducers } from '../reducers';

export const history = createBrowserHistory();

export default function configureStore(preloadedStore) {
    const store = createStore(
        Reducers(history),
        preloadedStore,
        compose(
            applyMiddleware(
                routerMiddleware(history)
            )
        )
    );

    return store;
}