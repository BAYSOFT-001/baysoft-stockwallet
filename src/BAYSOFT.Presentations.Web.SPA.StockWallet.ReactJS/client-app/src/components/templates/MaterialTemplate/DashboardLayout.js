import React, { Component } from 'react';
import { connect } from 'react-redux';

import ThemeProvider from './ThemeProvider';

import PersistentDrawerLeft from './PersistentDrawerLeft';

class DashboardLayout extends Component {
    render() {
        return (
            <ThemeProvider>
                <PersistentDrawerLeft>
                    {this.props.children}
                </PersistentDrawerLeft>
            </ThemeProvider>
        );
    }
}

const mapStateToProps = store => ({
    application: store.applicationState.application
});

export default connect(mapStateToProps)(DashboardLayout);
