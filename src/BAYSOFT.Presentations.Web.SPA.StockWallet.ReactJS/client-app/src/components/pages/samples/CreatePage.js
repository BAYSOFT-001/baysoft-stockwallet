import React, { useState } from 'react';
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
    IconButton,
    FormControl,
    TextField,
    Button,
    Grid
} from '@material-ui/core';

import {
    KeyboardBackspace
} from '@material-ui/icons';
import { CreateApiService } from '../../../state/actions/apiModelWrapper/actions';

const useStyles = makeStyles(theme => ({
    mainPaper: {
        minWidth: '300px',
        width: '100%',
        marginBottom: theme.spacing(2),
    },
    toolbarRoot: {
        paddingLeft: theme.spacing(2),
        paddingRight: theme.spacing(1),
    },
    toolbarTitle: {
        flex: '1 1 100%',
    },
    formRoot: {
        display: 'flex',
        flexWrap: 'wrap',
    },
    formMargin: {
        padding: theme.spacing(1),
    },
}));

const CreatePage = (props) => {
    const returnUrl = '/samples';
    const classes = useStyles();
    const [sample, setSample] = useState({ description: '' });

    const api = props.CreateApiService(`samples-service`, 'https://localhost:4101/api/samples');

    const handleClickBack = (event) => {
        props.push(returnUrl);
    };

    const handleChange = (prop) => (event) => {
        setSample({ ...sample, [prop]: event.target.value });
    };

    const handleClickSave = () => {
        api.Post(sample, returnUrl);
    };

    return (
        <Templates.MaterialTemplate.DashboardLayout>
            <Paper className={classes.mainPaper}>
                <Toolbar
                    className={classes.toolbarRoot}
                >
                    <Tooltip title="Voltar">
                        <IconButton aria-label="back" onClick={handleClickBack}>
                            <KeyboardBackspace />
                        </IconButton>
                    </Tooltip>

                    <Typography className={classes.toolbarTitle} variant="h6" id="tableTitle" component="div">
                        Create new sample
                    </Typography>
                </Toolbar>
                <Grid container spacing={0} className={classes.formRoot}>
                    <Grid container spacing={0} >
                        <Grid item xs={12}>
                            <FormControl fullWidth className={classes.formMargin} >
                                <TextField id="outlined-basic" label="Description" variant="outlined" value={sample.description} onChange={handleChange('description')} />
                            </FormControl>
                        </Grid>
                    </Grid>
                    <Grid container spacing={0} justify="flex-end" >
                        <Grid item lg={2} md={4} xs={6}>
                            <FormControl fullWidth className={classes.formMargin} >
                                <Button variant="contained" color="primary" onClick={handleClickSave}>Save</Button>
                            </FormControl>
                        </Grid>
                    </Grid>
                </Grid>
            </Paper>
        </Templates.MaterialTemplate.DashboardLayout>
    );
};

const mapStateToProps = store => ({
    application: store.applicationState.application
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        push,
        CreateApiService
    }, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(CreatePage);

export const routes = [
    { private: false, name: "SAMPLES_CREATE", path: "/samples/create", params: [], component: connectedComponent }
];

export default connectedComponent;