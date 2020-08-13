import React, { Component } from 'react';
import { connect } from 'react-redux';

import { Templates } from '../templates';

class NotFoundPage extends Component {
    render() {
        return (
            <Templates.MaterialTemplate.DashboardLayout>
                <h4>Not found!</h4>
                <hr/>
            </Templates.MaterialTemplate.DashboardLayout>
        );
    }
}

const mapStateToProps = store => ({
    application: store.applicationState.application
});

export default connect(mapStateToProps)(NotFoundPage);