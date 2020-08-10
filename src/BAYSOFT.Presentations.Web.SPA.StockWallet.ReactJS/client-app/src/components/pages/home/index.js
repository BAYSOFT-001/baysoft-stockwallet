import React, { Component } from 'react';
import { connect } from 'react-redux';

import logo from '../../../logo.svg';

class Index extends Component {
    render() {
        return (
            <div>
                <img src={logo} className="App-logo" alt="logo" />
            </div>
        );
    }
}

const mapStateToProps = store => ({
    application: store.applicationState.application
});

export default connect(mapStateToProps)(Index);
