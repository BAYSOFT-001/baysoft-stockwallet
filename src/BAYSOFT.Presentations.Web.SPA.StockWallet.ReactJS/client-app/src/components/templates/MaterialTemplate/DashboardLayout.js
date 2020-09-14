import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { ApplicationActionType } from '../../../state/actions';

import ThemeProvider from './ThemeProvider';
import PersistentDrawerLeft from './PersistentDrawerLeft';

import Snackbar from '@material-ui/core/Snackbar';
import MuiAlert from '@material-ui/lab/Alert';

function Alert(props) {
    return <MuiAlert elevation={6} variant="filled" {...props} />;
}


const DashboardLayout = (props) => {
    const { application } = props;
    const { snackBar } = application;
    return (
        <ThemeProvider>
            <PersistentDrawerLeft>
                {props.children}
            </PersistentDrawerLeft>

            <Snackbar open={snackBar.open} autoHideDuration={2500} onClose={() => { props.ApplicationNotificatioClose(); }}>
                <Alert onClose={() => { props.ApplicationNotificatioClose(); }} severity={snackBar.severity}>
                    {snackBar.message}
                </Alert>
            </Snackbar>
        </ThemeProvider>
    );
};

const {
    ApplicationNotificatioClose
} = ApplicationActionType.actions;

const mapStateToProps = store => ({
    application: store.ApplicationState.application,
    pathname: store.router.location.pathname,
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        ApplicationNotificatioClose,
    }, dispatch);

export default connect(mapStateToProps, mapDispatchToProps)(DashboardLayout);
