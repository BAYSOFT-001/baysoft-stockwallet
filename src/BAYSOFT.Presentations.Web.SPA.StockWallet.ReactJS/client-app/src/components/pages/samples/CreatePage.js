import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { push } from 'connected-react-router';

import { Templates } from '../../templates';

import {
    makeStyles,
    Paper,
    Toolbar,
    Typography,
    Tooltip,
    IconButton
} from '@material-ui/core';

import {
    KeyboardBackspace
} from '@material-ui/icons';

const useStyles = makeStyles(theme => ({
    mainPaper: {
        width: '100%',
        marginBottom: theme.spacing(2),
    },
    toolbarRoot: {
        paddingLeft: theme.spacing(2),
        paddingRight: theme.spacing(1),
    },
    toolbarTitle: {
        flex: '1 1 100%',
    }
}));

const CreatePage = (props) => {
    const classes = useStyles();

    const handleClickBack = (event) => {
        props.push('/samples');
    };

    return (
        <Templates.MaterialTemplate.DashboardLayout>
            <Paper className={classes.mainPaper}>
                <Toolbar
                    className={classes.toolbarRoot}
                >
                    <Typography className={classes.toolbarTitle} variant="h6" id="tableTitle" component="div">
                        Create new sample
                    </Typography>

                    <Tooltip title="Voltar">
                        <IconButton aria-label="back" onClick={handleClickBack}>
                            <KeyboardBackspace />
                        </IconButton>
                    </Tooltip>
                </Toolbar>
            </Paper>
        </Templates.MaterialTemplate.DashboardLayout>
    );
}

const mapStateToProps = store => ({
    application: store.applicationState.application
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        push
    }, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(CreatePage);

export const routes = [
    { private: false, name: "SAMPLES_CREATE", path: "/samples/create", params: [], component: connectedComponent }
];

export default connectedComponent;