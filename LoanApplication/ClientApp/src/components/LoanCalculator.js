import React, { useState, useEffect } from 'react';

const LoanCalculator = () => {

    const [items, setItems] = useState([]);

    const [selected, setSelected] = useState([]);

    const [calculate, setCalculate] = useState(true);

    const [paymentPlan, setPaymentPlan] = useState([]);


    useEffect(() => {
        if (selected !== []) {
            console.log('button pressed!');
            fetch('api/loan/' +
                (items.filter(value => value.loanName === selected).at(0)?.loanPeriods) + '/' +
                (items.filter(value => value.loanName === selected).at(0)?.loanSize))
                .then((result) => {
                    return result.json();
                })
                .then(data => {
                    setPaymentPlan(data);
                });
            console.log(paymentPlan);
        }
    },[calculate])

    useEffect(()=> {
        fetch('api/loan')
            .then((result) => {
                return result.json();
            })
            .then(data => {
                setItems(data);
            })
    }, [])

    useEffect(() => {
        if (selected !== []) {
                console.log(selected);
                items.forEach(item => console.log(item));
        }
    }, [selected])

    var e = document.getElementById("selection1");

    return (
        <main>
            <label>Pick a Loan Plan:
                <table>
                    <tr>
                        <th>Plan</th>
                        <th>Peroider</th>
                        <th>Rate</th>
                        <th>Antall</th>
                    </tr>
                    <tr>
                        <td>{items.filter(value => value.loanName === selected).at(0)?.loanName}</td>
                        <td>{items.filter(value => value.loanName === selected).at(0)?.loanPeriods}</td>
                        <td>{items.filter(value => value.loanName === selected).at(0)?.loanRate}</td>
                        <td>{items.filter(value => value.loanName === selected).at(0)?.loanSize}</td>
                    </tr>
                </table>
                <select id="selection1" onChange={() => setSelected(e.value)}>
                    {items.map((item) => <option key={item.loanName} value={item.loanName}>{item.loanName}</option>)}
                </select>
                <button onClick={()=> setCalculate(!calculate)}>Calculate Annual Payment Plan</button>
                <table>
                    <tr>
                        <th>år</th>
                        <th>Lån</th>
                        <th>Innbetalt</th>
                        <th>Renter</th>
                        <th>Total forandring</th>
                    </tr>
                    {Array.from(paymentPlan).map((val, i) => (
                        <tr>
                            <td>{i+1}</td>
                            <td>{val.loanLeft} kr</td>
                            <td>{val.loanSubtracted} kr</td>
                            <td>{val.loanAdded} kr</td>
                            <td>{val.loanChanged} kr</td>
                        </tr>
                    ))}
                </table>
            </label>
        </main>
    )
}



export default LoanCalculator;