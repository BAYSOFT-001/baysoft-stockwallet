import React, { Component } from 'react';

import {
    BrowserRouter,
    Route,
    Switch,
} from "react-router-dom";

import ROUTES from '../routes';

class Router extends Component {
    render() {
        return (
            <BrowserRouter>
                <Switch>
                    {ROUTES.map((route, index) =>
                        <Route exact
                            key={index}
                            name={route.name}
                            path={route.path}
                            params={route.params}
                            component={route.component}
                        />
                    )
                    }
                </Switch>
            </BrowserRouter>
        );
    }
}

export default Router;