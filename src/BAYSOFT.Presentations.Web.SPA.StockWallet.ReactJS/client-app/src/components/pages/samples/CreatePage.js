import React, { Component } from 'react';
import { connect } from 'react-redux';

import { Templates } from '../../templates';

class CreatePage extends Component {
    render() {
        return (
            <Templates.MaterialTemplate.DashboardLayout>
                <h4>Samples - Create</h4>
                <hr />
            </Templates.MaterialTemplate.DashboardLayout>
        );
    }
}

const mapStateToProps = store => ({
    application: store.applicationState.application
});

const connectedComponent = connect(mapStateToProps)(CreatePage);

export const routes = [
    { private: false, name: "SAMPLES_CREATE", path: "/samples/create", params: [], component: connectedComponent }
];

export default connectedComponent;