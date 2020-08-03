import * as React from 'react';
import { Route } from 'react-router';
import { Layout } from './components/templates';
import { Home, Counter, FetchData, Samples } from './components/pages';

import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/counter' component={Counter} />
        <Route exact path='/fetch-data/:startDateIndex?' component={FetchData} />
        <Route exact path='/samples' component={Samples.Index} />
        <Route exact path='/samples/new' component={Samples.New} />
        <Route exact path='/samples/edit/:id' component={Samples.Edit} />
        <Route exact path='/samples/delete/:id' component={Samples.Delete} />
    </Layout>
);
