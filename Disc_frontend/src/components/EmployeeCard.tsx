import { Card, CardBody, Heading, Image } from "@chakra-ui/react";
import type { Employee } from "../hooks/useEmployees";


interface Props {
    employee: Employee;
}

const EmployeeCard = ({ employee }: Props) => {
    return (
        <Card borderRadius="1" overflow="hidden">
            <Image src={employee.imagePath} alt={`${employee.firstName} ${employee.lastName}`} />
            <CardBody>
                <Heading size="md">{employee.firstName} {employee.lastName}</Heading>
            </CardBody>
        </Card>
    );
};
export default EmployeeCard;