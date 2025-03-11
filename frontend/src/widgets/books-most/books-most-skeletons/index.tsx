import { Flex, Skeleton } from '@gravity-ui/uikit'

export default function BooksMostSkeletons() {
	return (
		<Flex direction={'column'} gap={2}>
			<Skeleton
				style={{
					width: '100%',
					height: 20,
				}}
			/>
			<Skeleton
				style={{
					width: '80%',
					height: 20,
				}}
			/>
			<Skeleton
				style={{
					width: '90%',
					height: 20,
				}}
			/>
		</Flex>
	)
}
