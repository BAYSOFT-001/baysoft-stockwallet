import * as React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../../../store';

type DeleteProps =
    RouteComponentProps<{ id: string }>;

class Delete extends React.PureComponent<DeleteProps> {
    public render() {
        return (
            <React.Fragment>
                <h4>Samples</h4>
                <h6 className="text-muted">Are you sure you want to delete the sample?</h6>
                <hr />

                <div className="row">
                    <div className="col">
                        body...
                    </div>
                </div>

                <hr />

                <div className="row">
                    <div className="col">
                        <Link className="btn btn-link" to="/samples">Back</Link>
                    </div>
                </div>
            </React.Fragment>
        );
    }
};

export default connect()(Delete as any);