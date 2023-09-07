import * as React from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import InputLabel from '@mui/material/InputLabel';
import OutlinedInput from '@mui/material/OutlinedInput';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import TextField from '@mui/material/TextField';

export default function PlegerSelectDialog({animal,okClick,cancelClick}) {
    
    
    
    const [columnName, setColumnName] = React.useState('');
    const [newData, setNewData] = React.useState();

    const handleChange = (event) => {
        setColumnName(event.target.value || '');
    };


    return (
        <div>
           
            <Dialog open={true}>
                <DialogTitle>Daten Ändern {animal.gattung}</DialogTitle>
                <DialogContent>
                    
                    <FormControl sx={{ m: 1, minWidth: 120 }}>
                        <InputLabel>Category</InputLabel>
                        <Select
                            value={columnName}
                            onChange={handleChange}
                            input={<OutlinedInput label="Age" />}
                        >
                            <MenuItem value="">
                                <em>None</em>
                            </MenuItem>
                            <MenuItem value={"gattung"}>Gattung</MenuItem>
                            <MenuItem value={"nahrung"}>Nahrung</MenuItem>
                            <MenuItem value={"gehegeId"}>GehegeId</MenuItem>
                        </Select>
                        <TextField onChange={(e)=>{ setNewData(e.target.value)}} value={newData} label="Neue Daten" variant="outlined" />
                    </FormControl>
                    
                </DialogContent>
                <DialogActions>
                    <Button onClick={()=>{cancelClick()}}>Cancel</Button>
                    <Button onClick={()=>{okClick(animal.id,columnName,newData)}}>Ok</Button>
                </DialogActions>
            </Dialog>
        </div>
    );
}

