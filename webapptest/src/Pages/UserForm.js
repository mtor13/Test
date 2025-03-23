import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from 'yup';
import { postUser } from '../api';
import { useEffect, useState } from 'react';
import {
	TextField,
	FormControlLabel,
	Checkbox,
	MenuItem,
	Button,
	Box,
	FormHelperText,
} from '@mui/material';

const countries = [
	{ code: 'CRI', name: 'Costa Rica' },
	{ code: 'MEX', name: 'México' },
	{ code: 'USA', name: 'Estados Unidos' },
	{ code: 'CAN', name: 'Canadá' },
	{ code: 'ESP', name: 'España' },
	{ code: 'FRA', name: 'Francia' },
	{ code: 'DEU', name: 'Alemania' },
	{ code: 'ITA', name: 'Italia' },
	{ code: 'GBR', name: 'Reino Unido' },
	{ code: 'JPN', name: 'Japón' },
];

const schema = yup.object().shape({
	idUsuario: null,
	nombre: yup.string().required('Nombre es obligatorio'),
	apellido: yup.string().required('Apellido es obligatorio'),
	correoElectronico: yup.string().email('Correo inválido').required('Correo es obligatorio'),
	fechaNacimiento: yup.string().required('Fecha de Nacimiento es obligatoria'),
	telefono: yup
		.string()
		.nullable()
		.transform(value => (value === '' ? null : value))
		.test('is-number', 'Solo se permiten números', value => {
			if (value === null) return true;
			return /^\d+$/.test(value);
		}),
	paisResidencia: yup.string().required('País de residencia obligatorio'),
	contacto: yup.boolean(),
});

const isNullOrUndefined = prop => prop === null || prop === undefined;
const isEmptyString = prop => isNullOrUndefined(prop) || prop === '';
const capitalize = word => word.charAt(0).toUpperCase() + word.slice(1).toLowerCase();

function titleFromName(name) {
	if (isEmptyString(name)) {
		return '';
	}

	return name
		.split(/(?=[A-Z])|\s/)
		.map(s => capitalize(s))
		.join(' ');
}

export default function UserForm({ onUserAdded }) {
	const {
		register,
		handleSubmit,
		reset,
		formState: { errors },
		watch,
	} = useForm({
		resolver: yupResolver(schema),
		defaultValues: {
			contacto: false,
			paisResidencia: '',
		},
	});

	const contacto = watch('contacto');

	const onSubmit = async data => {
		try {
			console.log(data);
			await postUser(data);
			reset();
			//onUserAdded(); // Refresh list
		} catch (error) {
			alert('Error submitting form');
		}
	};

	return (
		<Box
			component="form"
			onSubmit={handleSubmit(onSubmit)}
			sx={{
				display: 'flex',
				flexDirection: 'column',
				gap: 2,
				maxWidth: 400,
				mx: 'auto',
				p: 3,
			}}
		>
			<TextField
				{...register('nombre')}
				label="Nombre"
				fullWidth
				error={!!errors.nombre}
				helperText={errors.nombre?.message}
			/>

			<TextField
				{...register('apellido')}
				label="Apellido"
				fullWidth
				error={!!errors.apellido}
				helperText={errors.apellido?.message}
			/>

			<TextField
				{...register('correoElectronico')}
				label="Correo Electrónico"
				type="email"
				fullWidth
				error={!!errors.correoElectronico}
				helperText={errors.correoElectronico?.message}
			/>

			<TextField
				{...register('fechaNacimiento')}
				label="Fecha de Nacimiento"
				type="date"
				fullWidth
				InputLabelProps={{
					shrink: true,
				}}
				error={!!errors.fechaNacimiento}
				helperText={errors.fechaNacimiento?.message}
			/>

			<TextField
				{...register('telefono')}
				label="Teléfono"
				type="number"
				fullWidth
				error={!!errors.telefono}
				helperText={errors.telefono?.message}
				inputProps={{
					inputMode: 'numeric',
					pattern: '[0-9]*',
					onKeyPress: e => {
						if (!/[0-9]/.test(e.key)) {
							e.preventDefault();
						}
					},
				}}
			/>

			<TextField
				{...register('paisResidencia')}
				select
				label="País de Residencia"
				fullWidth
				error={!!errors.paisResidencia}
				helperText={errors.paisResidencia?.message}
				SelectProps={{
					value: watch('paisResidencia') || '',
				}}
			>
				<MenuItem value="">
					<em>Seleccione un país</em>
				</MenuItem>
				{countries.map(country => (
					<MenuItem
						key={country.code}
						value={country.code}
					>
						{country.name}
					</MenuItem>
				))}
			</TextField>

			<FormControlLabel
				control={
					<Checkbox
						{...register('contacto')}
						checked={contacto}
					/>
				}
				label="¿Desea recibir información?"
			/>

			<Button
				type="submit"
				variant="contained"
				color="primary"
				sx={{ mt: 2 }}
			>
				Grabar
			</Button>
		</Box>
	);
}
