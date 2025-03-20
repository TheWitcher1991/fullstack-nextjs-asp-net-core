import { Flex, Pagination, Text } from '@gravity-ui/uikit'
import { CSSProperties, useEffect } from 'react'

import BooksSearchInput from '~widgets/books-search/books-search-input'
import { useBooksSearchStore } from '~widgets/books-search/books-search.store'

import BookList from '~features/book-list'
import BookSkeletonList from '~features/book-skeleton-list/index.tsx'

import { useBooks } from '~models/book'

import { RenderFetchData } from '~packages/lib'
import { Spacing } from '~packages/ui'

const textStyle: CSSProperties = {
	display: 'block',
	textAlign: 'center',
}

function EmptyMessage() {
	return (
		<Text variant={'body-3'} style={textStyle}>
			Ничего не найдено
		</Text>
	)
}

export default function BooksSearch() {
	const {
		setLoading,
		setList,
		setCount,
		loading,
		count,
		list,
		filter,
		setFilter,
	} = useBooksSearchStore()
	const { isLoading, data } = useBooks(filter)

	useEffect(() => {
		setLoading(isLoading)
		if (!isLoading && data?.data) {
			setList(data.data.result)
			setCount(data.data.result.length)
		}
	}, [isLoading, data])

	return (
		<>
			<BooksSearchInput />

			<Flex gap={4} direction={'column'}>
				<RenderFetchData
					isLoading={loading}
					countData={count}
					emptyFallback={<EmptyMessage />}
					loadingFallback={<BookSkeletonList />}
				>
					{!filter.search ? (
						<EmptyMessage />
					) : (
						<>
							<BookList books={list} />
							<div></div>
							<Pagination
								page={filter.page || 1}
								pageSize={filter.pageSize || 15}
								total={count}
								compact={true}
								showPages={true}
								onUpdate={(page, pageSize) => {
									setFilter({
										page,
										pageSize,
									})
								}}
							/>
						</>
					)}
				</RenderFetchData>
			</Flex>
		</>
	)
}
