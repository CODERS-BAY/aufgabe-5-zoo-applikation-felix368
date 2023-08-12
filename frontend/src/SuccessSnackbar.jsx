import * as React from 'react';
import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';
import Snackbar from '@mui/material/Snackbar';
import MuiAlert from '@mui/material/Alert';

const Alert = React.forwardRef(function Alert(props, ref) {
    return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
});

export default function SuccessSnackbar() {
    

    return (
        <Snackbar open={true}>
            <Alert  severity="success" sx={{ width: '100%' }}>
                Die Tickets wurden erfolgreich gespeichert!
            </Alert>
        </Snackbar>
       
    );
}
