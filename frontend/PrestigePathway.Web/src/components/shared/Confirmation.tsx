import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
} from "@mui/material";
import React from "react";

interface IConfirmation {
  title: string;
  buttonText: string;
  handler: () => Promise<void>;
  open: boolean;
  onClose: () => void;
  text: string;
}

const Confirmation: React.FC<IConfirmation> = (props) => {
  return (
    <Dialog
      open={props.open}
      onClose={props.onClose}
      aria-labelledby="confirmation-dialog-title"
      aria-describedby="confirmation-dialog-description"
    >
      <DialogTitle id="confirmation-dialog-title">{props.title}</DialogTitle>
      <DialogContent>
        <DialogContentText id="confirmation-dialog-description">
          {props.text}
        </DialogContentText>
      </DialogContent>
      <DialogActions>
        <Button onClick={props.onClose} color="secondary">
          Cancel
        </Button>
        <Button onClick={props.handler} color="primary" autoFocus>
          {props.buttonText}
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default Confirmation;
