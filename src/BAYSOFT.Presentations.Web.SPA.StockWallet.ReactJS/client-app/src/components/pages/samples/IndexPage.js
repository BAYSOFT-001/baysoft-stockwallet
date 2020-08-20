import React, { Component } from 'react';
import { connect } from 'react-redux';

import { Templates } from '../../templates';

import EnchancedTable from '../../molecules/EnhancedTable';

import ApiConnectedTable from '../../organisms/ApiConnectedTable';

class IndexPage extends Component {
    render() {
        return (
            <Templates.MaterialTemplate.DashboardLayout>
                <ApiConnectedTable endpoint={'https://localhost:4101/api/samples'}/>
                <hr/>
                <EnchancedTable/>
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
