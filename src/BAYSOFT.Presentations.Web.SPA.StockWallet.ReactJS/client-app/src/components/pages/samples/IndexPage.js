import React, { Component } from 'react';
import { connect } from 'react-redux';

import { Templates } from '../../templates';

import EnchancedTable from '../../molecules/EnhancedTable';

import ApiConnectedTable from '../../organisms/ApiConnectedTable';

const config = {
    title: 'List of samples',
    endpoint: 'https://localhost:4101/api/samples',
    id: 'sampleID',
    dense: false,
    columns: [{
        id: 'description',
        isNumeric: false,
        disablePadding: false,
        label: 'Description'
    }],
    actions: {
        'add': { handler: () => { console.log('click: addHandler'); } },
        'edit': { handler: (id) => { console.log('click: editHandler'); } },
        'delete': { handler: (ids) => { console.log('click: deleteHandler'); } }
    }
};

class IndexPage extends Component {
    render() {
        return (
            <Templates.MaterialTemplate.DashboardLayout>
                <ApiConnectedTable config={config} />
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
