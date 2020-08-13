import React, { Component } from 'react';
import { connect } from 'react-redux';

import { Templates } from '../../templates';

class EditPage extends Component {
    render() {
        return (
            <Templates.MaterialTemplate.DashboardLayout>
                <h4>Samples - Edit</h4>
                <hr />
            </Templates.MaterialTemplate.DashboardLayout>
        );
    }
}

const mapStateToProps = store => ({
    application: store.applicationState.application
});

const connectedComponent = connect(mapStateToProps)(EditPage);

export const routes = [
    { private: false, name: "SAMPLES_EDIT", path: "/samples/edit", params: [], component: connectedComponent }
];

export default connectedComponent;
