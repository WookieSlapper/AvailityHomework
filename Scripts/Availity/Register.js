
class RegisterForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            company: {
                LastName: '',
                FirstName: '',
                NPINumber: '',
                BusAdd1: '',
                BusAdd2: '',
                City: '',
                State: '',
                Zip: '',
                Phone: '',
                Email: ''
            }
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = event.target.value;
        const name = target.name;
        if (name === "phone") {
            if (!Number(value)) {
                alert("Your phone number must be numbers only");
            }
        }
        //would include other validations in a production context

        this.setState({
            company: {
                ...this.state.company,
                [name]: value
            }
        });
    }

    handleSubmit(event) {
        alert('A form was submitted: ' + this.state.value);
        let companyInfo = {
            LastName: this.refs.value,
            FirstName: this.refs.FirstName.value,
            NPINumber: this.refs.NPINumber.value,
            Add1: this.refs.Add1.value,
            City: this.refs.City.value,
            State: this.refs.State.value,
            Zip: this.refs.Zip.value,
            Phone: this.refs.Phone.value,
            Email: this.refs.Email.value
        }
        event.preventDefault();
    }

    onCreateCompany = () => {
        console.log(this.state.LastName);
    }


    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <label>
                    Last Name:
                    <input name="lastname" ref="LastName" type="text" value={this.state.company.LastName} onChange={this.handleChange}> </input>
                </label>
                <label>
                    First Name:
                    <input name="firstname" ref="FirstName" type="text" value={this.state.company.FirstName} onChange={this.handleChange}> </input>
                </label>
                <label>
                    NPI Number:
                    <input name="npinumber" ref="NPINumber" type="text" value={this.state.company.NPINumber} onChange={this.handleChange}> </input>
                </label>
                <label>
                    Business Address Line 1:
                    <input name="busadd1" ref="BusAdd1" type="text" value={this.state.company.BusAdd1} onChange={this.handleChange}> </input>
                </label>
                <label>
                    Business Address Line 2:
                    <input name="busadd2" ref="BusAdd2" type="text" value={this.state.company.BusAdd2} onChange={this.handleChange}> </input>
                </label>
                <label>
                    City:
                    <input name="city" ref="City" type="text" value={this.state.company.City} onChange={this.handleChange}> </input>
                </label>
                <label>
                    State:
                    <input name="state" ref="State" type="text" value={this.state.company.State} onChange={this.handleChange}> </input>
                </label>
                <label>
                    Zip Code:
                    <input name="zip" ref="Zip" type="text" value={this.state.company.Zip} onChange={this.handleChange}> </input>
                </label>
                <label>
                    Telephone:
                    <input name="phone" ref="Phone" type="text" value={this.state.company.Phone} onChange={this.handleChange}> </input>
                </label>
                <label>
                    Email:
                    <input name="email" ref="Email" type="text" value={this.state.company.Email} onChange={this.handleChange}> </input>
                </label>

                <input type="submit" value="Submit" onClick={this.onCreateCompany}> </input>
            </form>
        );
    }
}

const domContainer = document.querySelector('#register');
ReactDOM.render(e(RegisterForm), domContainer);