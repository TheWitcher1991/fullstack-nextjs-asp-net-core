import { Flex } from '@gravity-ui/uikit'
import { useEffect } from 'react'

import BooksMostList from '~widgets/books-most/books-most-list'
import BooksMostSkeletons from '~widgets/books-most/books-most-skeletons'
import { useBooksMostStore } from '~widgets/books-most/books-most.store'

import { useBooks } from '~models/book'

import { RenderFetchData } from '~packages/lib'
import { Section } from '~packages/ui'

export default function BooksMost() {
	const { setLoading, setList, setCount, loading, count, list, filter } =
		useBooksMostStore()
	const { isLoading, data } = useBooks(filter)

	useEffect(() => {
		setLoading(isLoading)
		if (!isLoading && data?.data) {
			setList(data.data.result)
			setCount(data.data.result.length)
		}
	}, [isLoading, data])

	return (
		<Section header={'Сейчас популярно'}>
			<Flex gap={2} wrap={'wrap'}>
				<RenderFetchData
					isLoading={loading}
					countData={count}
					loadingFallback={<BooksMostSkeletons />}
				>
					<BooksMostList books={list} />
				</RenderFetchData>
			</Flex>
		</Section>
	)
}
