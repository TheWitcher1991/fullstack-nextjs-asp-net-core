import { Flex, Text } from '@gravity-ui/uikit'

import { IBook } from '~models/book'

import { formatDateInRu } from '~packages/utils'

interface BookOverviewTagsProps {
	book: IBook
}

function BookTag({ label, content }: { label: string; content: string }) {
	return (
		<Flex gap={2} alignItems={'center'}>
			<Text color={'secondary'} variant={'body-2'}>
				{label}
			</Text>
			<Text variant={'body-2'}>{content}</Text>
		</Flex>
	)
}

export default function BookOverviewTags({ book }: BookOverviewTagsProps) {
	return (
		<Flex direction={'column'} gap={2}>
			<BookTag
				label={'Возрастные ограничения:'}
				content={`${book.age}+`}
			/>
			{book.holder && (
				<BookTag label={'Правообладатель:'} content={book.holder} />
			)}

			<BookTag label={'Издательство:'} content={book.publisher} />
			{book.translator && (
				<BookTag label={'Переводчик:'} content={book.translator} />
			)}
			{book.pages && (
				<BookTag label={'Бумажных страниц:'} content={book.pages} />
			)}
			<BookTag
				label={'Опубликовано:'}
				content={formatDateInRu(book.createdAt)}
			/>
		</Flex>
	)
}
