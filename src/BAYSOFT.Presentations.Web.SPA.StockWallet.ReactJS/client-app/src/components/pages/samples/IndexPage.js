import React, { Component } from 'react';
import { connect } from 'react-redux';

import { Templates } from '../../templates';

class IndexPage extends Component {
    render() {
        return (
            <Templates.MaterialTemplate.DashboardLayout>
                <h4>Samples - Index</h4>
                <hr />
            </Templates.MaterialTemplate.DashboardLayout>
        );
    }
}

const mapStateToProps = store => ({
    application: store.applicationState.application
});

const connectedComponent = connect(mapStateToProps)(IndexPage);

export const routes = [
    { private: false, name: "SAMPLES", path: "/samples", params: [], component: connectedComponent },
    { private: false, name: "SAMPLES_INDEX", path: "/samples/index", params: [], component: connectedComponent }
];

export default connectedComponent;
