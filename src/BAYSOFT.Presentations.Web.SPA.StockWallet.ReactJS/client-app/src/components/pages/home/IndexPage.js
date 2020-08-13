import React, { Component } from 'react';
import { connect } from 'react-redux';

import { Templates } from '../../templates';

import Typography from '@material-ui/core/Typography';

class IndexPage extends Component {
    render() {
        return (
            <Templates.MaterialTemplate.DashboardLayout>
                <Typography variant="h6" noWrap>
                    Home/Index - data...
                </Typography>
            </Templates.MaterialTemplate.DashboardLayout>
        );
    }
}

const mapStateToProps = store => ({
    application: store.applicationState.application
});

const connectedComponent = connect(mapStateToProps)(IndexPage);

export const routes = [
    { private: false, name: "HOME", path: "/home", params: [], component: connectedComponent },
    { private: false, name: "HOME_INDEX", path: "/home/index", params: [], component: connectedComponent }
];

export default connectedComponent;
