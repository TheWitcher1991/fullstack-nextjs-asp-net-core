import { Magnifier } from '@gravity-ui/icons'
import { Icon, TextInput } from '@gravity-ui/uikit'

export default function BooksSearchInput() {
	return (
		<TextInput
			placeholder={'Книги, авторы, жанры...'}
			size={'xl'}
			startContent={
				<div style={{ marginInline: 6 }}>
					<Icon data={Magnifier} size={18} />
				</div>
			}
		/>
	)
}
