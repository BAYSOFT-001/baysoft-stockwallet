import React, { Component } from 'react';
import { connect } from 'react-redux';
import { MuiThemeProvider, createMuiTheme } from '@material-ui/core';

import blue from '@material-ui/core/colors/blue';
import deepOrange from '@material-ui/core/colors/deepOrange';

const appTheme = createMuiTheme({
    typography: {
        useNextVariants: true
    },
    palette: {
        primary: blue,
        secondary: deepOrange,
    }
})

class ThemeProvider extends Component {
    render() {
        return (
            <MuiThemeProvider theme={appTheme}>
                {this.props.children}
            </MuiThemeProvider>
        );
    }
}

const mapStateToProps = store => ({
    application: store.ApplicationState.application
});

export default connect(mapStateToProps)(ThemeProvider);
