import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';



export default function PflegerAnimalList({value,onTableRowClick}) {
    console.log(value[0])



    return (
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell align="center">ID</TableCell>
                        <TableCell align="center">Name</TableCell>
                        <TableCell align="center">Nahrung</TableCell>
                        <TableCell align="center">Gehege</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {value.map((row) => (
                        <TableRow
                            key={row.name}
                            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            className="PflegerAnimalList"
                            onClick={() => {
                                onTableRowClick(row.id);
                            }}
                        >
                            <TableCell align="center">{row.id}</TableCell>
                            <TableCell align="center">{row.gattung}</TableCell>
                            <TableCell align="center">{row.nahrung}</TableCell>
                            <TableCell align="center">{row.gehegeId}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
}