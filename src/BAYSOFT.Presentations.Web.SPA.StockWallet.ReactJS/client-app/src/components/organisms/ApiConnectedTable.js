import React, { Component } from 'react';
import { connect } from 'react-redux';

class ApiConnectedTable extends Component {
    getData = () => {
        fetch(this.props.endpoint)
            .then(data => data.json())
    }
    render() {
        return (
            <React.Fragment>
                Api connected table (without table) => API EndPoint: {this.props.endpoint}
            </React.Fragment>
        );
    }
}

const mapStateToProps = store => ({
    application: store.applicationState.application
});

const connectedComponent = connect(mapStateToProps)(ApiConnectedTable);

export default connectedComponent;
