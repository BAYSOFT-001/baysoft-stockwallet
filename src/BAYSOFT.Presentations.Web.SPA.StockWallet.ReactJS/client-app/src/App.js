import React, { Component } from 'react';
import { connect } from 'react-redux';

import { Navigation } from './navigation';

import './App.css';

class App extends Component {
    render() {
        return (<Navigation.Router />);
    }
}

const mapStateToProps = store => ({
    application: store.applicationState.application
});

export default connect(mapStateToProps)(App);
