import Table from "react-bootstrap/Table";
import Form from "react-bootstrap/Form";
import InputGroup from "react-bootstrap/InputGroup";
import Col from "react-bootstrap/esm/Col";
import { useEffect, useState } from "react";
import { getPartipants } from "../../services/http/endpoints/participants";
import { IParticipant } from "../../@types/models/participant";
import ParticipantItem from "./components/ParticipantItem";

function ParticipantsList() {
	const [participants, setPartipants] = useState<IParticipant[]>([]);
	const [search, setSearch] = useState<string>("");

	const removeAccents = (str: string) =>
		str.normalize("NFD").replace(/[\u0300-\u036f]/g, "");

	const filteredParticipants = participants.filter((participant) => {
		return removeAccents(participant.name.toLowerCase()).includes(
			removeAccents(search.toLowerCase()).trim()
		);
	});

	useEffect(() => {
		getPartipants().then((response) => setPartipants(response.data.data));
	}, []);

	function onSearchChange(value: string) {
		setSearch(value);
	}

	return (
		<div className="mt-4 container">
			<Col className="d-flex flex-column align-items-start">
				<Form.Label htmlFor="search">Pesquise o banco desejado: </Form.Label>
				<InputGroup className="mb-3">
					<Form.Control
						id="search"
						value={search}
						onChange={(ev) => onSearchChange(ev.target.value)}
						placeholder="Pesquisar..."
					/>
				</InputGroup>
			</Col>
			{filteredParticipants.length ? (
				<Table bordered hover>
					<thead>
						<tr>
							<th className="bg-light">Imagem</th>
							<th className="text-start">Nome</th>
							<th className="text-start">Url de Autenticação</th>
						</tr>
					</thead>
					<tbody>
						{filteredParticipants.map((participant) => {
							return <ParticipantItem participant={participant} />;
						})}
					</tbody>
				</Table>
			) : (
				<h3 className="m-5">Nenhum banco encontrado</h3>
			)}
		</div>
	);
}

export default ParticipantsList;
