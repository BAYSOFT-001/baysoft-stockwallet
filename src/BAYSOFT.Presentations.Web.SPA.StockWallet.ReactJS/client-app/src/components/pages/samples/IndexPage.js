import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { push } from 'connected-react-router';

import { Templates } from '../../templates';

import ApiConnectedTable from '../../organisms/ApiConnectedTable';
import { CreateApiService } from '../../../state/actions/apiModelWrapper/actions';

const IndexPage = (props) => {
    const config = {
        title: 'List of samples',
        configId: 'samples-index-table',
        endPoint: 'https://localhost:4101/api/samples',
        id: 'sampleID',
        dense: false,
        defaultPageSize: 5,
        columns: [{
            id: 'description',
            isNumeric: false,
            disablePadding: false,
            label: 'Description'
        }],
        actions: {
            'add': { handler: () => { redirectToAdd(); } },
            'edit': { handler: (id) => { redirectToEdit(id); } },
            'delete': { handler: (ids) => { deleteHandler(ids); } }
        }
    };
    const api = props.CreateApiService(`samples-service`, 'https://localhost:4101/api/samples');
    const deleteHandler = (ids) => {
        ids.map(id => api.Delete(id));
    };
    const redirectToAdd = () => {
        props.push('/samples/create');
    };
    const redirectToEdit = (id) => {
        props.push(`/samples/edit/${id}`);
    };

    return (
        <Templates.MaterialTemplate.DashboardLayout>
            <ApiConnectedTable config={config} />
        </Templates.MaterialTemplate.DashboardLayout>
    );
}

const mapStateToProps = store => ({
    application: store.ApplicationState.application
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        push,
        CreateApiService
    }, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(IndexPage);

export const routes = [
    { private: false, name: "SAMPLES", path: "/samples", params: [], component: connectedComponent },
    { private: false, name: "SAMPLES_INDEX", path: "/samples/index", params: [], component: connectedComponent }
];

export default connectedComponent;