import React, { Component } from 'react';
import { connect } from 'react-redux';

import { Templates } from '../../templates';

import logo from '../../../logo.svg';

class Index extends Component {
    render() {
        return (
            <Templates.MaterialTemplate.DashboardLayout>
                <div>
                    <img src={logo} className="App-logo" alt="logo" />
                </div>
            </Templates.MaterialTemplate.DashboardLayout>
        );
    }
}

const mapStateToProps = store => ({
    application: store.applicationState.application
});

export default connect(mapStateToProps)(Index);
