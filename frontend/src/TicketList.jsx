import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';



export default function TicketList({ value, onTableRowClick }) {
    if(value === undefined){
        return(<></>)
    }
    let Tickets = value.results;


    if(Tickets === undefined){
        return(
            <></>
        )
    }
    console.log(Tickets);




    return (
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell>City Name</TableCell>
                        <TableCell align="right">country</TableCell>
                        <TableCell align="right">State</TableCell>
                        <TableCell align="right">Latitude</TableCell>
                        <TableCell align="right">Longitude</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {Tickets.map((row) => (
                        <TableRow
                            key={row.id}
                            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            className="geoRow"
                        >
                            <TableCell component="th" scope="row">
                                {row.name}
                            </TableCell>
                            <TableCell align="right">{row.admin1}</TableCell>
                            <TableCell align="right">{row.country }</TableCell>
                            <TableCell align="right">{row.latitude}</TableCell>
                            <TableCell value = {[row.latitude,row.longitude]} align="right">{row.longitude}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );


}