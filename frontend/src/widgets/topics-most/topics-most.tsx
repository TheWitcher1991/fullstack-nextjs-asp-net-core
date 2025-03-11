'use client'

import { Flex } from '@gravity-ui/uikit'

import TopicsMostSkeletons from '~widgets/topics-most/topics-most-skeletons'

export default function TopicsMost() {
	return (
		<>
			<Flex gap={2} wrap={'wrap'}>
				<TopicsMostSkeletons />
			</Flex>
		</>
	)
}
