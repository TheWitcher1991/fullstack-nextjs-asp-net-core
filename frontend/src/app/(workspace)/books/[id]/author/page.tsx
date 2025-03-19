'use client'

import BookLoading from '../loading'
import { use } from 'react'

import BookOverview from '~widgets/book-overview'

import { AuthorCard, IAuthor } from '~models/author'
import { IBook, useBook } from '~models/book'

import { RenderFetchData } from '~packages/lib'

export default function BookAuthorPage({
	params,
}: {
	params: Promise<{ id: string }>
}) {
	const { id } = use(params)
	const { isLoading, data } = useBook(id)

	return (
		<>
			<RenderFetchData
				isLoading={isLoading}
				loadingFallback={<BookLoading />}
			>
				<BookOverview book={data?.data.result as IBook}>
					<AuthorCard author={data?.data.result.author as IAuthor} />
				</BookOverview>
			</RenderFetchData>
		</>
	)
}
