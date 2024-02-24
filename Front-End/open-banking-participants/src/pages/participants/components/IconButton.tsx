import React from "react";

interface IconButtonProps {
	children: JSX.Element;
	onClick?: (ev: React.MouseEvent<HTMLButtonElement, MouseEvent>) => void;
}

function IconButton({ children, onClick }: IconButtonProps) {
	return (
		<button className="bg-transparent border-0 mx-1" onClick={onClick}>
			{children}
		</button>
	);
}

export default IconButton;
