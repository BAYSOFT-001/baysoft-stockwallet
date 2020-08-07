import * as React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../../../store';

type EditProps =
    RouteComponentProps<{ id: string }>;

class Edit extends React.PureComponent<EditProps> {
    public render() {
        return (
            <React.Fragment>
                <h4>Samples</h4>
                <h6 className="text-muted">Edit sample</h6>
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

export default connect()(Edit as any);