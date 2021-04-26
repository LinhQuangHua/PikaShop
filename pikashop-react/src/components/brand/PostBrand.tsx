import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import Edit from "../../services/Edit";
import Create from "../../services/Create";

export default ({ itemEdit }: any) => {

    const [nameBrand, setName] = useState('');

    React.useEffect(() => {
        console.log(itemEdit)
        if (itemEdit != null)
            setName(itemEdit.Name);
    }, [itemEdit])

    const handleChange = (event: any) => {
        setName(event.target.value);
    }

    const handleSubmit = (event: any) => {
        event.preventDefault();
        if (itemEdit == null) {
            Create("brands", { name: nameBrand })
                .then(res => {
                    console.log({ name: nameBrand });
                }).catch(err => {
                    console.log(err);
                })
        }
        else {

            Edit("brands", itemEdit.Id, { name: nameBrand })
                .then(res => {
                    console.log({ name: nameBrand });
                }).catch(err => {
                    console.log(err);
                })
        }
    }

    return (
        <>
            <br />
            <h5>Add new brand</h5>
            <Form inline onSubmit={handleSubmit}>
                <FormGroup className="mb-2 mr-sm-2 mb-sm-0">
                    <Label for="exampleEmail" className="mr-sm-2">Name</Label>
                    <Input type="text" name="name_brand" value={nameBrand} placeholder="New brand..." onChange={handleChange} />
                </FormGroup>
                <Button type="submit">{itemEdit ? "Save" : "Add"}</Button>
            </Form>
            <hr />
        </>
    )
}

