import React, { Component } from 'react';
import { connect } from 'react-redux';

import { Themplates } from './components/templates';

import { Pages } from './components/pages';

import './App.css';

class App extends Component {
    render() {
        return (
            <Themplates.MaterialThemplate.DashboardLayout>
                <Pages.Home.Index></Pages.Home.Index>
            </Themplates.MaterialThemplate.DashboardLayout>
        );
    }
}

const mapStateToProps = store => ({
    application: store.applicationState.application
});

export default connect(mapStateToProps)(App);
