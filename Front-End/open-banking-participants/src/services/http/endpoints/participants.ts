import { IParticipant } from "../../../@types/models/participant";
import { IGenericResponse } from "../../../@types/models/generic-response";
import http from "../http";

export async function getPartipants() {
	return await http.get<IGenericResponse<IParticipant[]>>("/participants");
}
