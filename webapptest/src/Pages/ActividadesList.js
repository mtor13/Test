import { useEffect, useState } from 'react';
import { getActividades } from '../api';
import {
  Box,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Typography,
  Container,
} from '@mui/material';

export default function ActividadesList({ refresh }) {
  const [actividades, setActividades] = useState([]);

  useEffect(() => {
    const Actividades = async () => {
      const data = await getActividades();
      setActividades(data);
    };
    Actividades();
  }, [refresh]);

  return (
    <Container
      maxWidth="lg"
      sx={{ py: 4 }}
    >
      <Typography
        variant="h4"
        component="h1"
        gutterBottom
        sx={{ mb: 3 }}
      >
        Historial de Actividades
      </Typography>

      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>              
              <TableCell>Fecha</TableCell>
              <TableCell>Usuario</TableCell>
              <TableCell>Actividad</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {actividades.map(act => (
              <TableRow key={act.id_actividad}>
                <TableCell>{new Date(act.createDate).toISOString().split('T')[0]}</TableCell>
                <TableCell>{act.nombreUsuario}</TableCell>
                <TableCell>{act.actividad}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Container>
  );
}
