import React, { Component } from 'react';
import { connect } from 'react-redux';
import { MuiThemeProvider, createMuiTheme } from '@material-ui/core';

import primary from '@material-ui/core/colors/blue';
import secondary from '@material-ui/core/colors/lightBlue';

const appTheme = createMuiTheme({
    typography: {
        useNextVariants: true
    },
    palette: {
        primary: primary,
        secondary: secondary
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
