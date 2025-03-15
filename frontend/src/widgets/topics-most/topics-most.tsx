'use client'

import { Flex } from '@gravity-ui/uikit'
import { useEffect } from 'react'

import TopicsMostSkeletons from '~widgets/topics-most/topics-most-skeletons'
import { useTopicsMostStore } from '~widgets/topics-most/topics-most.store'

import TopicList from '~features/topic-list'

import { useTopics } from '~models/topic'

import { RenderFetchData } from '~packages/lib'

export default function TopicsMost() {
	const { setLoading, setList, setCount, loading, count, list } =
		useTopicsMostStore()
	const { isLoading, data } = useTopics()

	useEffect(() => {
		setLoading(isLoading)
		if (!isLoading && data?.data) {
			setList(data.data.result)
			setCount(data.data.result.length)
		}
	}, [isLoading, data])

	return (
		<Flex gap={2} wrap={'wrap'}>
			<RenderFetchData
				isLoading={loading}
				countData={count}
				loadingFallback={<TopicsMostSkeletons />}
			>
				<TopicList topics={list} />
			</RenderFetchData>
		</Flex>
	)
}
