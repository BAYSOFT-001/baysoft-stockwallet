import React, { useEffect } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { Templates } from '../../templates';

import {
    Typography,
    Button
} from '@material-ui/core';
import { CreateApiService, CreateApiFilter } from '../../../state/actions/apiModelWrapper/actions';

const IndexPage = (props) => {
    const { requests } = props;
    console.log(requests);
    const handleClickCallThunkWithDifferentEndpoint = () => {
        console.log('clicked: Call thunk!');

        let api = props.CreateApiService('home-index-stocks', 'https://localhost:4101/api/stocks');

        let filter = props.CreateApiFilter('home-index-stock-filter');

        filter.clear()
            .setPagination(20, 1);

        api.GetByFilter(filter);
    }
    const handleClickCallThunk = () => {
        console.log('clicked: Call thunk!');

        let api = props.CreateApiService('home-index-samples', 'https://localhost:4101/api/samples');

        api.GetById(1);
    };
    const handleClickCallThunkWrappedAPI = () => {
        let api = props.CreateApiService('home-index-samples', 'https://localhost:4101/api/samples');
        
        let filter = props.CreateApiFilter('home-index-sample-filter');

        filter.clear()
            .addFilter('description_contains', '002')
            .setSearch('sample')
            .setOrdenation('sampleID', 'ascending')
            .setPagination(5, 1);
        
        api.GetByFilter(filter);
    };
    useEffect(() => {
        console.log('useEffect => requests');
        console.log(requests);
    }, [requests])
    return (
        <Templates.MaterialTemplate.DashboardLayout>
            <Typography variant="h6" noWrap>
                Home/Index - data...
            </Typography>

            <Button variant="contained" color="primary" onClick={handleClickCallThunk}>Call thunk!</Button>
            <Button variant="contained" color="primary" onClick={handleClickCallThunkWithDifferentEndpoint}>Call thunk with a diferrent endpoint!</Button>
            <Button variant="contained" color="primary" onClick={handleClickCallThunkWrappedAPI}>Wrapped API</Button>
        </Templates.MaterialTemplate.DashboardLayout>
    );
}

const mapStateToProps = store => ({
    application: store.applicationState.application,
    requests: store.ApiModelWrapperState.requests
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        CreateApiService,
        CreateApiFilter
    }, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(IndexPage);

export const routes = [
    { private: false, name: "HOME", path: "/home", params: [], component: connectedComponent },
    { private: false, name: "HOME_INDEX", path: "/home/index", params: [], component: connectedComponent }
];

export default connectedComponent;
