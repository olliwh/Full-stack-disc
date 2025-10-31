import { Box, Card, CardBody, Heading, HStack, Image } from "@chakra-ui/react";
import type { Employee } from "../hooks/useEmployees";


interface Props {
  employee: Employee;
}

const EmployeeCard = ({ employee }: Props) => {
  // const color = '#' +  employee.discType.color;
  // console.log(color);

  return (
    <Card borderRadius="1" overflow="hidden">
      <Image
        src={employee.imagePath}
        alt={`${employee.firstName} ${employee.lastName}`}
        width="100%"
        height={"240px"}
        objectFit="cover"
        objectPosition="center top"
      />
      <CardBody>
        <HStack spacing={4}>

          <Heading size="md">
            {employee.firstName} {employee.lastName}
          </Heading>
          {/* <Box
            width="15px"
            height="15px"
            borderRadius="50%"
            backgroundColor={color}
            flexShrink={0} // Prevents the circle from shrinking
          /> */}
        </HStack>
      </CardBody>
    </Card>
  );
};
export default EmployeeCard;
