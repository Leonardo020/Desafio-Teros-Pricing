import { useState } from "react";
import { IParticipant } from "../../../@types/models/participant";
import IconButton from "./IconButton";

interface ParticipantItemProps {
	participant: IParticipant;
}

function ParticipantItem({ participant }: ParticipantItemProps) {
	const [copied, setCopied] = useState<string>("");

	function onCopy(
		ev: React.MouseEvent<HTMLButtonElement, MouseEvent>,
		participant: IParticipant
	): void {
		ev.stopPropagation();
		navigator.clipboard.writeText(participant.discoveryUrl);
		//concat both fields to ensure uniqueness
		setCopied(participant.id + participant.discoveryUrl);
		setTimeout(() => setCopied(""), 1400);
	}

	return (
		<tr>
			<td style={{ width: "66px" }} className="bg-light">
				<img
					className="d-block rounded-circle mx-2"
					onError={(ev) => {
						ev.currentTarget.src = "/default.png";
					}}
					width={50}
					height={50}
					src={participant.logoUrl}
					alt={participant.name}
				/>
			</td>
			<td className="text-start align-middle">
				{participant.name.toUpperCase()}
			</td>
			<td className="text-start align-middle">
				<a target="_blank" rel="noreferrer" href={participant.discoveryUrl}>
					{participant.discoveryUrl}
				</a>
				{participant.discoveryUrl.length ? (
					<IconButton onClick={(ev) => onCopy(ev, participant)}>
						{copied.includes(participant.id + participant.discoveryUrl) ? (
							<img src="/check_icon.svg" alt="" />
						) : (
							<img src="/copy_icon.svg" alt="" />
						)}
					</IconButton>
				) : (
					<p className="m-0 opacity-75">Url não encontrada</p>
				)}
			</td>
		</tr>
	);
}

export default ParticipantItem;
